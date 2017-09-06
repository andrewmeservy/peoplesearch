(function() {
	var module = angular.module("peopleSearch", []);

	module.factory("personService", function ($http) {
		return {
			getAll: function () {
				return $http.get('/Person/GetAll')
					.then(function (response) {
						return response.data;
					}, function () {
						alert('error');
					});
			},
			search: function (name) {
				return $http.get('/Person/GetByName', { params: { name: name } })
					.then(function (response) {
						return response.data;
					}, function () {
						alert('error');
					});
			}
		};
	});

	module.controller("personController", function ($scope, personService) {
		var getAll = function () {
			personService.getAll().then(function (data) {
				$scope.people = data;
				isSlowSearchFilter = false;
			})
		};
		getAll();

		var isSlowSearchFilter = false;
		$scope.search = function (name) {
			if (name !== null && name !== "") {
				$("#loadingSpinner").show();
				$(".hideOnSearch").hide();

				personService.search(name).then(function (data) {
					$("#loadingSpinner").hide();
					$(".hideOnSearch").show();
					$scope.people = data;
					isSlowSearchFilter = true;
				});
			}
		}

		$scope.onSearchTextChanged = function (name) {
			if (isSlowSearchFilter === true || name === null || name === "" ) {
				getAll();
			}
		}
	});
} ());
