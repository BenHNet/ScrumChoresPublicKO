/// <reference path="../../../typings/knockout/knockout.d.ts" />

module scrumChores.models {

    export class sprint {

        SprintID: KnockoutObservable<string>;
        SprintName: KnockoutObservable<string>;
        SprintStartDate: KnockoutObservable<Date>;
        SprintEndDate: KnockoutObservable<Date>;
        SprintDateRange: KnockoutComputed<String>;

        constructor(SprintID: string, SprintName: string, SprintStartDate: Date, SprintEndDate: Date) {
            this.SprintID = ko.observable(SprintID);
            this.SprintName = ko.observable(SprintName);
            this.SprintStartDate = ko.observable(SprintStartDate);
            this.SprintEndDate = ko.observable(SprintEndDate);
            var self = this;
            this.SprintDateRange = ko.computed(function () {
                return self.SprintStartDate() + ' - ' + self.SprintEndDate();
            });
        }

    }
}

         