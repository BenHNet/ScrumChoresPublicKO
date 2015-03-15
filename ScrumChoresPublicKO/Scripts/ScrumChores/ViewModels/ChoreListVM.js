scrumChores.choreListVM = {
    sprints: ko.observableArray([]),
    currentSprint: ko.observable(new scrumChores.models.sprint("", "", "", "")),
    dialogNewSprint: {},
    baseURL: "http://localhost/ScrumChoresPublicKO",

    // Get sprint data
    getSprintData: function () {
        while (scrumChores.choreListVM.sprints().length > 0) {
            scrumChores.choreListVM.sprints.pop();
        }

        $.getJSON(scrumChores.choreListVM.baseURL + "/API/Sprint", function (allData) {
            $.map(allData, function (item) { scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint(item.SprintID, item.SprintName, item.SprintStartDate, item.SprintEndDate)) });

            if (scrumChores.choreListVM.sprints().length > 0 && scrumChores.choreListVM.currentSprint().SprintName() == "") {
                scrumChores.choreListVM.currentSprint(scrumChores.choreListVM.sprints()[0]);
                scrumChores.choreListVM.getStoryData(scrumChores.choreListVM.currentSprint().SprintID());
            }
            else if (scrumChores.choreListVM.currentSprint().SprintName() != "") {
                scrumChores.choreListVM.getStoryData(scrumChores.choreListVM.currentSprint().SprintID());
            }
            else {
                while (scrumChores.choreListVM.stories().length > 0) {
                    scrumChores.choreListVM.stories.pop();
                }
            }
        });

    },

    sprintSelected: function (data) {
        scrumChores.choreListVM.currentSprint(data);
        scrumChores.choreListVM.getStoryData(scrumChores.choreListVM.currentSprint().SprintID());
    },

    showNewSprintDialog: function () {
        scrumChores.choreListVM.currentSprint(new scrumChores.models.sprint("", "", "", ""));
        scrumChores.choreListVM.dialogNewSprint.dialog("open");
    },

    showEditSprintDialog: function () {
        scrumChores.choreListVM.dialogNewSprint.dialog("open");
    },

    deleteSprint: function () {
        $.ajax(scrumChores.choreListVM.baseURL + "/API/Sprint", {
            data: ko.toJSON(scrumChores.choreListVM.currentSprint().SprintID()),
            type: "delete", contentType: "application/json",
            success: function (result) {
                scrumChores.choreListVM.getSprintData();
            }
        });
    },

    createSprint: function () {
        $.ajax(scrumChores.choreListVM.baseURL + "/API/Sprint", {
            data: ko.toJSON(scrumChores.choreListVM.currentSprint()),
            type: "post", contentType: "application/json",
            success: function (result) {
                scrumChores.choreListVM.getSprintData();
                scrumChores.choreListVM.dialogNewSprint.dialog("close");
            }
        });
    },

    // Story data    
    stories: ko.observableArray([]),
    currentStory: ko.observable(new scrumChores.models.story(new scrumChores.models.sprint("", "", "", ""), "", "", "", "")),
    dialogNewStory: {},

    // Get story data
    getStoryData: function (SprintID) {
        while (scrumChores.choreListVM.stories().length > 0) {
            scrumChores.choreListVM.stories.pop();
        }

        $.getJSON(scrumChores.choreListVM.baseURL + "/API/Story", function (allData) {
            $.map(allData, function (item) {
                if (item.Sprint.SprintID == scrumChores.choreListVM.currentSprint().SprintID()) {
                    scrumChores.choreListVM.stories.push(new scrumChores.models.story(new scrumChores.models.sprint(item.Sprint.SprintID, item.Sprint.SprintName, item.Sprint.SprintStartDate, item.Sprint.SprintEndDate), item.StoryID, item.Title, item.Description, item.Effort))
                }
            });
        });
    },

    showNewStoryDialog: function () {
        scrumChores.choreListVM.currentStory(new scrumChores.models.story(scrumChores.choreListVM.currentSprint, "", "", "", ""));
        scrumChores.choreListVM.dialogNewStory.dialog("open");
    },

    createStory: function () {
        $.ajax(scrumChores.choreListVM.baseURL + "/API/Story", {
            data: ko.toJSON(scrumChores.choreListVM.currentStory()),
            type: "post", contentType: "application/json",
            success: function (result) {
                scrumChores.choreListVM.getStoryData();
                scrumChores.choreListVM.dialogNewStory.dialog("close");
            }
        });
    }
}

scrumChores.choreListVM.getSprintData();
ko.applyBindings(scrumChores.choreListVM);

scrumChores.choreListVM.dialogNewSprint = $("#dialog-sprintForm").dialog({
    autoOpen: false,
    height: 310,
    width: 500,
    modal: true,
    buttons: {
        "Save": scrumChores.choreListVM.createSprint,
        Cancel: function () {
            scrumChores.choreListVM.dialogNewSprint.dialog("close");
        }
    },
    close: function () {
    }
});

scrumChores.choreListVM.dialogNewStory = $("#dialog-storyForm").dialog({
    autoOpen: false,
    height: 310,
    width: 500,
    modal: true,
    buttons: {
        "Save": scrumChores.choreListVM.createStory,
        Cancel: function () {
            scrumChores.choreListVM.dialogNewStory.dialog("close");
        }
    },
    close: function () {
    }
});