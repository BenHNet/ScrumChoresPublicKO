/// <reference path="../../../typings/knockout/knockout.d.ts" />

module scrumChores.models {

    export class story {

        Sprint: KnockoutObservable<sprint>;
        StoryID: KnockoutObservable<string>;
        Title: KnockoutObservable<string>;
        Description: KnockoutObservable<string>;
        Effort: KnockoutObservable<string>;

        constructor(Sprint: sprint, StoryID: string, Title: string, Description: string, Effort: string) {
            this.Sprint = ko.observable(Sprint);
            this.StoryID = ko.observable(StoryID);
            this.Title = ko.observable(Title);
            this.Description = ko.observable(Description);
            this.Effort = ko.observable(Effort);
        }

    }
}
         