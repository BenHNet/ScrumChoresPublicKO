scrumChores.models.story = (function (StoryID, Title, Description, Effort) {
    var self = this;
    self.StoryID = ko.observable(StoryID);
    self.Title = ko.observable(Title);
    self.Description = ko.observable(Description);
    self.Effort = ko.observable(Effort);
});
         