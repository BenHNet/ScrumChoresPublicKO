scrumChores.models.sprint = (function (SpritnName, SprintStartDate, SprintEndDate) {
    var self = this;
    self.SprintName = ko.observable(SpritnName);
    self.SprintStartDate = ko.observable(SprintStartDate);
    self.SprintEndDate = ko.observable(SprintEndDate);
    self.SprintDateRange = ko.computed(function () {
        return this.SprintStartDate() + ' - ' + this.SprintEndDate();
    }, self);
});
         