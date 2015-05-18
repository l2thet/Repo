/// <reference path="angular.js" />
(function () {
    var app = angular.module("TrackedConversations", ['ui.bootstrap']);

    app.controller('ConversationsCtrl', ['$http', '$log', '$scope', function ($http, $log, $scope) {
        var self = this;
        self.items = [];
        $http.get('/tracker/retrieveTrackedConversations').
            success(function (data) {
                self.items = data;
            }).
            error(function (data) {
                $log.log(data);
            });

        $scope.$on('child', function (event, data) {
            self.items.push(data);
        });

        self.removeItem = function (item) {
            $http.post('/tracker/deleteTrackedConversation', JSON.stringify(item)).
                success(function (data) {
                    self.items = data;
                }).
                error(function (data) {
                    $log.log(data);
                });

        };

    }]);

    app.controller('NewConversationCtrl', ['$http', '$log', '$scope', function ($http, $log, $scope) {
        var self = this;
        self.dateTime = new Date();
        self.setting = "";
        self.who = "";
        self.rateOfUnease = 0;
        self.notes = "";
        self.dateOpened = false;
        self.mytime = new Date();
        self.open = function () {
            self.dateOpened = true;
        };

        self.addConvo = function () {
            var submissiondata = {};
            submissiondata.Date = new Date(self.dateTime.getUTCFullYear() + "-" + (self.dateTime.getMonth() + 1) + "-" + self.dateTime.getDate() + " " + self.mytime.getHours() + ":" + self.mytime.getMinutes() + ":00");
            submissiondata.SettingOrEnvironment = self.setting;
            submissiondata.Who = self.who;
            submissiondata.RateOfUnease = self.rateOfUnease;
            submissiondata.NotesOfChangeOverTime = self.notes;

            $http.post('/tracker/saveTrackedConversation', JSON.stringify(submissiondata)).
                success(function (data) {
                    $scope.$emit('child', data);
                    self.dateTime = new Date();
                    self.setting = "";
                    self.who = "";
                    self.rateOfUnease = 0;
                    self.notes = "";
                }).
                error(function (data) {
                    $log.log(data);
                });
        };
    }]);

    app.directive('customNumberValidation', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {

                modelCtrl.$parsers.push(function (inputValue) {
                    var transformedInput = inputValue.toLowerCase().replace(/[a-z]/g, '');

                    if (transformedInput != inputValue) {

                        modelCtrl.$setViewValue(transformedInput);
                        modelCtrl.$render();
                    }

                    return transformedInput;
                });
            }
        };
    });

})();