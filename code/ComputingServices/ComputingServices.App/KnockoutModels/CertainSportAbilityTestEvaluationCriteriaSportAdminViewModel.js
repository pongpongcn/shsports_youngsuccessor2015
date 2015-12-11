/// <reference path="../Statics/knockout/knockout-3.4.0.js" />
/// <reference path="../Statics/jquery/jquery-1.11.3.js" />

// Define a "Sport" class that tracks its own info(id, code, name), and has a method to save.
function SportViewModel(id, code, name) {
    var self = this;

    self.id = ko.observable(id);
    self.code = ko.observable(code);
    self.name = ko.observable(name);

    self.save = function () {
        var dataObject = ko.toJSON(self);

        if (self.id() != null) {
            $.ajax({
                url: baseUrl + 'api/certainsportabilitytestevaluationcriteriasport/' + self.id(),
                type: 'PUT',
                data: dataObject,
                contentType: 'application/json',
                success: function () {
                    var sport = ko.utils.arrayFirst(appViewModel.sportList.sports(), function (item) {
                        return item.id() == self.id();
                    });

                    sport.code(self.code());
                    sport.name(self.name());
                    
                    self.id(null);
                    self.code('');
                    self.name('');
                }
            });
        }
        else {
            $.ajax({
                url: baseUrl + 'api/certainsportabilitytestevaluationcriteriasport',
                type: 'POST',
                data: dataObject,
                contentType: 'application/json',
                success: function (data) {
                    appViewModel.sportList.sports.push(new SportViewModel(data.Id, data.Code, data.Name));

                    self.id(null);
                    self.code('');
                    self.name('');
                }
            });
        }
    };
}

// use as student list view's view model
function SportListViewModel() {
    var self = this;
    // observable arrays are update binding elements upon array changes
    self.sports = ko.observableArray([]);

    self.load = function () {
        self.sports.removeAll();

        // retrieve students list from server side and push each object to model's students list
        $.getJSON(baseUrl + 'api/certainsportabilitytestevaluationcriteriasport', function (data) {
            $.each(data, function (key, value) {
                self.sports.push(new SportViewModel(value.Id, value.Code, value.Name));
            });
        });
    };

    self.editItem = function (sport) {
        var target = appViewModel.sportEditing;
        target.id(sport.id());
        target.code(sport.code());
        target.name(sport.name());
    };
    // remove student. current data context object is passed to function automatically.
    self.removeItem = function (sport) {
        $.ajax({
            url: baseUrl + 'api/certainsportabilitytestevaluationcriteriasport/' + sport.id(),
            type: 'DELETE',
            contentType: 'application/json',
            success: function () {
                self.sports.remove(sport);
            }
        });
    };
}

// The view model is an abstract description of the state of the UI, but without any knowledge of the UI technology (HTML)
var appViewModel = {
    sportEditing : new SportViewModel(),
    sportList : new SportListViewModel()
}

// on document ready
$(document).ready(function () {
    // bind view model to referring view
    ko.applyBindings(appViewModel);

    // load student data
    appViewModel.sportList.load();
});