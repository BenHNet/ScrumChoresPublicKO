scrumChores.choreListVM = {
    // Editable data    
    sprints: ko.observableArray([]),
    currentSprint: new scrumChores.models.sprint("", "", ""),
    dialogNewSprint: {},

    // Get data
    getData: function () {  
        while (scrumChores.choreListVM.sprints().length > 0) {
            scrumChores.choreListVM.sprints.pop();
        }

        $.getJSON("/API/Sprint", function (allData) {
            $.map(allData, function (item) { scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint(item.SprintName, item.SprintStartDate, item.SprintEndDate)) });
        });
    },

    showNewSprintDialog: function () {
        scrumChores.choreListVM.currentSprint = new scrumChores.models.sprint("", "", "");
        scrumChores.choreListVM.dialogNewSprint.dialog("open");
    },

    createSprint: function() {
        $.ajax("/API/Sprint", {
            data: ko.toJSON(scrumChores.choreListVM.currentSprint),
            type: "post", contentType: "application/json",
            success: function (result) {
                scrumChores.choreListVM.getData();
                scrumChores.choreListVM.dialogNewSprint.dialog("close");
            }
        });
    }
}

scrumChores.choreListVM.getData();
ko.applyBindings(scrumChores.choreListVM);
    
scrumChores.choreListVM.dialogNewSprint = $("#dialog-form").dialog({
    autoOpen: false,
    height: 310,    
    width: 500,     
    modal: true,    
    buttons: {
        "Create Sprint": scrumChores.choreListVM.createSprint,
        Cancel: function () {
            scrumChores.choreListVM.dialogNewSprint.dialog("close");
        }
    },
    close: function () {    
    }
});