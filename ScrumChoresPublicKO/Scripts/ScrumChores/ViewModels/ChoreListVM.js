scrumChores.choreListVM = {
    // Editable data    
    sprints: ko.observableArray([]),

    // Get data
    getData: function () {
        scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint("Test", "1/1/2015", "2/1/2015"));
        scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint("Test 1", "3/1/2015", "4/1/2015"));
        scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint("Test 2", "5/1/2015", "6/1/2015"));

        $.getJSON("/API/Sprint", function (allData) {
            $.map(allData, function (item) { scrumChores.choreListVM.sprints.push(new scrumChores.models.sprint(item.SprintName, item.SprintStartDate, item.SprintEndDate)) });
        });
    }
}

scrumChores.choreListVM.getData();
ko.applyBindings(scrumChores.choreListVM);