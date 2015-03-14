scrumChores.models.sprint = (function (SprintID, SpritnName, SprintStartDate, SprintEndDate) {
    var self = this;
    self.SprintID = ko.observable(SprintID);
    self.SprintName = ko.observable(SpritnName);
    self.SprintStartDate = ko.observable(SprintStartDate);
    self.SprintEndDate = ko.observable(SprintEndDate);
    self.SprintDateRange = ko.computed(function () {
        return this.SprintStartDate() + ' - ' + this.SprintEndDate();
    }, self);
});
         