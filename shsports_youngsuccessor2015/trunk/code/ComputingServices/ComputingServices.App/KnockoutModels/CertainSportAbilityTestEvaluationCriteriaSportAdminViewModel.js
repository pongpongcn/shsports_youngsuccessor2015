﻿/// <reference path="../Statics/knockout/knockout-3.4.0.js" />
/// <reference path="../Statics/jquery/jquery-1.11.3.js" />

var sportAdminViewModel;

// use as add sport view's view model
function Sport(id, code, name) {
    var self = this;

    // observable are update elements upon changes, also update on element data changes [two way binding]
    self.Id = ko.observable(id);
    self.Code = ko.observable(code);
    self.Name = ko.observable(name);

    self.saveSport = function () {
        var dataObject = ko.toJSON(this);

        if (self.Id() != null) {
            $.ajax({
                url: baseUrl + 'api/certainsportabilitytestevaluationcriteriasport/' + self.Id(),
                type: 'PUT',
                data: dataObject,
                contentType: 'application/json',
                success: function () {
                    var sport = ko.utils.arrayFirst(sportAdminViewModel.sportListViewModel.sports(), function (item) {
                        return item.Id() == self.Id();
                    });

                    sport.Code(self.Code());
                    sport.Name(self.Name());
                    
                    self.Id(null);
                    self.Code('');
                    self.Name('');
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
                    sportAdminViewModel.sportListViewModel.sports.push(new Sport(data.Id, data.Code, data.Name));

                    self.Id(null);
                    self.Code('');
                    self.Name('');
                }
            });
        }
    };
}

// use as student list view's view model
function SportList() {
    var self = this;
    // observable arrays are update binding elements upon array changes
    self.sports = ko.observableArray([]);

    self.getSports = function () {
        self.sports.removeAll();

        // retrieve students list from server side and push each object to model's students list
        $.getJSON(baseUrl + 'api/certainsportabilitytestevaluationcriteriasport', function (data) {
            $.each(data, function (key, value) {
                self.sports.push(new Sport(value.Id, value.Code, value.Name));
            });
        });
    };

    self.editSport = function (sport) {
        var target = sportAdminViewModel.sportEditorViewModel;
        target.Id(sport.Id());
        target.Code(sport.Code());
        target.Name(sport.Name());
    };
    // remove student. current data context object is passed to function automatically.
    self.removeSport = function (sport) {
        $.ajax({
            url: baseUrl + 'api/certainsportabilitytestevaluationcriteriasport/' + sport.Id(),
            type: 'DELETE',
            contentType: 'application/json',
            success: function () {
                self.sports.remove(sport);
            }
        });
    };
}

// create index view view model which contain two models for partial views
sportAdminViewModel = { sportEditorViewModel: new Sport(), sportListViewModel: new SportList() };

// on document ready
$(document).ready(function () {
    // bind view model to referring view
    ko.applyBindings(sportAdminViewModel);

    // load student data
    sportAdminViewModel.sportListViewModel.getSports();
});