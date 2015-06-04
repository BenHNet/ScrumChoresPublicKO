/// <reference path="../../../typings/knockout/knockout.d.ts" />
var scrumChores;
(function (scrumChores) {
    var models;
    (function (models) {
        var story = (function () {
            function story(Sprint, StoryID, Title, Description, Effort) {
                this.Sprint = ko.observable(Sprint);
                this.StoryID = ko.observable(StoryID);
                this.Title = ko.observable(Title);
                this.Description = ko.observable(Description);
                this.Effort = ko.observable(Effort);
            }
            return story;
        })();
        models.story = story;
    })(models = scrumChores.models || (scrumChores.models = {}));
})(scrumChores || (scrumChores = {}));
//# sourceMappingURL=Story.js.map