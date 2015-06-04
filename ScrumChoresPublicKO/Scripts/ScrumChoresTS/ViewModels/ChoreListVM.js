/// <reference path="../../typings/knockout/knockout.d.ts" />
/// <reference path="../Common/Models/Sprint.ts" />
/// <reference path="../Common/Models/Story.ts" />
var scrumChores;
(function (scrumChores) {
    var choreListVM = (function () {
        function choreListVM() {
            var _this = this;
            this.sprints = ko.observableArray([]);
            this.currentSprint = ko.observable(new scrumChores.models.sprint("", "", new Date(), new Date()));
            this.dialogNewSprint = {};
            this.stories = ko.observableArray([]);
            this.currentStory = ko.observable(new scrumChores.models.story(new scrumChores.models.sprint("", "", new Date(), new Date()), "", "", "", ""));
            this.dialogNewStory = {};
            this.baseURL = "http://localhost/ScrumChoresPublicKO";
            this.getSprintData = function () {
                var self = _this;
                while (self.sprints().length > 0) {
                    self.sprints().pop();
                }
                $.getJSON(self.baseURL + "/API/Sprint", function (allData) {
                    $.map(allData, function (item) {
                        self.sprints.push(new scrumChores.models.sprint(item.SprintID, item.SprintName, item.SprintStartDate, item.SprintEndDate));
                    });
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
            };
            this.sprintSelected = function (data) {
                _this.currentSprint(data);
                _this.getStoryData(_this.currentSprint().SprintID());
            };
            this.showNewSprintDialog = function () {
                _this.currentSprint(new scrumChores.models.sprint("", "", new Date(), new Date()));
                _this.dialogNewSprint.dialog("open");
            };
            this.showEditSprintDialog = function () {
                _this.dialogNewSprint.dialog("open");
            };
            this.deleteSprint = function () {
                var self = _this;
                $.ajax(self.baseURL + "/API/Sprint", {
                    data: ko.toJSON(self.currentSprint().SprintID()),
                    type: "delete",
                    contentType: "application/json",
                    success: function (result) {
                        self.getSprintData();
                    }
                });
            };
            this.createSprint = function () {
                $.ajax(_this.baseURL + "/API/Sprint", {
                    data: ko.toJSON(_this.currentSprint()),
                    type: "post",
                    contentType: "application/json",
                    success: function (result) {
                        this.getSprintData();
                        this.dialogNewSprint.dialog("close");
                    }
                });
            };
            // Get story data
            this.getStoryData = function (SprintID) {
                var self = _this;
                while (self.stories().length > 0) {
                    self.stories.pop();
                }
                $.getJSON(self.baseURL + "/API/Story", function (allData) {
                    $.map(allData, function (item) {
                        if (item.Sprint.SprintID == self.currentSprint().SprintID()) {
                            self.stories.push(new scrumChores.models.story(new scrumChores.models.sprint(item.Sprint.SprintID, item.Sprint.SprintName, item.Sprint.SprintStartDate, item.Sprint.SprintEndDate), item.StoryID, item.Title, item.Description, item.Effort));
                        }
                    });
                });
            };
            this.showNewStoryDialog = function () {
                _this.currentStory(new scrumChores.models.story(_this.currentSprint(), "", "", "", ""));
                _this.dialogNewStory.dialog("open");
            };
            this.createStory = function () {
                var self = _this;
                $.ajax(self.baseURL + "/API/Story", {
                    data: ko.toJSON(self.currentStory()),
                    type: "post",
                    contentType: "application/json",
                    success: function (result) {
                        self.getStoryData(self.currentSprint().SprintID);
                        self.dialogNewStory.dialog("close");
                    }
                });
            };
        }
        return choreListVM;
    })();
    scrumChores.choreListVM = choreListVM;
})(scrumChores || (scrumChores = {}));
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
//# sourceMappingURL=ChoreListVM.js.map