/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../Common/Models/Sprint.ts" />
/// <reference path="../Common/Models/Story.ts" />

declare var $;

module scrumChores {

    export class choreListVM {

        sprints: KnockoutObservableArray<models.sprint> = ko.observableArray([]);
        currentSprint: KnockoutObservable<models.sprint> = ko.observable(new scrumChores.models.sprint("", "", new Date(), new Date()));
        dialogNewSprint: any = {};


        stories: KnockoutObservableArray<models.story> = ko.observableArray([]);
        currentStory: KnockoutObservable<models.story> = ko.observable(new scrumChores.models.story(new scrumChores.models.sprint("", "", new Date(), new Date()), "", "", "", ""));
        dialogNewStory: any = {};

        baseURL: string = "http://localhost/ScrumChoresPublicKO";

        getSprintData = () => {
            var self = this;
            while (self.sprints().length > 0) {
                self.sprints().pop();
            }

            $.getJSON(self.baseURL + "/API/Sprint", function (allData) {
                $.map(allData, function (item) { self.sprints.push(new models.sprint(item.SprintID, item.SprintName, item.SprintStartDate, item.SprintEndDate)) });

                if (self.sprints().length > 0 && self.currentSprint().SprintName() == "") {
                    self.currentSprint(self.sprints()[0]);
                    self.getStoryData(self.currentSprint().SprintID());
                }
                else if (self.currentSprint().SprintName() != "") {
                    self.getStoryData(self.currentSprint().SprintID());
                }
                else {
                    while (self.stories().length > 0) {
                        self.stories.pop();
                    }
                }
            });
        }

        sprintSelected = (data) => {
            this.currentSprint(data);
            this.getStoryData(this.currentSprint().SprintID());
        }

        showNewSprintDialog = () => {
            this.currentSprint(new models.sprint("", "", new Date(), new Date()));
            this.dialogNewSprint.dialog("open");
        }

        showEditSprintDialog = () => {
            this.dialogNewSprint.dialog("open");
        }

        deleteSprint = () => {
            var self = this;
            $.ajax(self.baseURL + "/API/Sprint", {
                data: ko.toJSON(self.currentSprint().SprintID()),
                type: "delete", contentType: "application/json",
                success: function (result) {
                    self.getSprintData();
                }
            });
        }

        createSprint = () => {
            $.ajax(this.baseURL + "/API/Sprint", {
                data: ko.toJSON(this.currentSprint()),
                type: "post", contentType: "application/json",
                success: function (result) {
                    this.getSprintData();
                    this.dialogNewSprint.dialog("close");
                }
            });
        }

        // Get story data
        getStoryData = (SprintID) => {
            var self = this;
            while (self.stories().length > 0) {
                self.stories.pop();
            }

            $.getJSON(self.baseURL + "/API/Story", function (allData) {
                $.map(allData, function (item) {
                    if (item.Sprint.SprintID == self.currentSprint().SprintID()) {
                        self.stories.push(new models.story(new scrumChores.models.sprint(item.Sprint.SprintID, item.Sprint.SprintName, item.Sprint.SprintStartDate, item.Sprint.SprintEndDate), item.StoryID, item.Title, item.Description, item.Effort))
                    }
                });
            });
        }

        showNewStoryDialog = () => {
            this.currentStory(new models.story(this.currentSprint(), "", "", "", ""));
            this.dialogNewStory.dialog("open");
        }

        createStory = () => {
            var self = this;
            $.ajax(self.baseURL + "/API/Story", {
                data: ko.toJSON(self.currentStory()),
                type: "post", contentType: "application/json",
                success: function (result) {
                    self.getStoryData(self.currentSprint().SprintID);
                    self.dialogNewStory.dialog("close");
                }
            });
        }

    }
}

var vm = new scrumChores.choreListVM();
vm.getSprintData();
ko.applyBindings(vm);

vm.dialogNewSprint = $("#dialog-sprintForm").dialog({
    autoOpen: false,
    height: 310,
    width: 500,
    modal: true,
    buttons: {
        "Save": vm.createSprint,
        Cancel: function () {
            vm.dialogNewSprint.dialog("close");
        }
    },
    close: function () {
    }
});

vm.dialogNewStory = $("#dialog-storyForm").dialog({
    autoOpen: false,
    height: 310,
    width: 500,
    modal: true,
    buttons: {
        "Save": vm.createStory,
        Cancel: function () {
            vm.dialogNewStory.dialog("close");
        }
    },
    close: function () {
    }
});