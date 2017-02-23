app.controller('APIController', function ($scope, APIService) {
   //getAll();
  

   $scope.createAccount = function() {
       var newAcc = {
           accountName: $scope.accName,
           accountEmail: $scope.accEmail,
           accountContact: $scope.accContact
       };

        var servCall = APIService.createNewAccount(newAcc);

        servCall.then(function (d) {
            $scope.account = d.data;
        }, function (error) {
            console.log('oops');
        }
        )
   }

   $scope.addMission = function () {
       var newMission = {
           "missionStatement": $scope.missionStatement,
           "userAccountId": $scope.account.id
       };

       var servCall = APIService.createNewMission(newMission);

       servCall.then(function successCallback(d) {
           $scope.mission = d.data;
       }, function (error) {
           console.log('oops');
       }
       )
   }
       
   


});