/// <reference path="../../../typings/knockout/knockout.d.ts" />
var scrumChores;
(function (scrumChores) {
    var models;
    (function (models) {
        var sprint = (function () {
            function sprint(SprintID, SprintName, SprintStartDate, SprintEndDate) {
                this.SprintID = ko.observable(SprintID);
                this.SprintName = ko.observable(SprintName);
                this.SprintStartDate = ko.observable(SprintStartDate);
                this.SprintEndDate = ko.observable(SprintEndDate);
                var self = this;
                this.SprintDateRange = ko.computed(function () {
                    return self.SprintStartDate() + ' - ' + self.SprintEndDate();
                });
            }
            return sprint;
        })();
        models.sprint = sprint;
    })(models = scrumChores.models || (scrumChores.models = {}));
})(scrumChores || (scrumChores = {}));
//# sourceMappingURL=Sprint.js.map