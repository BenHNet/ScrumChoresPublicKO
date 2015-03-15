scrumChores.models.story = (function (Sprint, StoryID, Title, Description, Effort) {
    var self = this;
    self.Sprint = ko.observable(Sprint);
    self.StoryID = ko.observable(StoryID);
    self.Title = ko.observable(Title);
    self.Description = ko.observable(Description);
    self.Effort = ko.observable(Effort);
});
         