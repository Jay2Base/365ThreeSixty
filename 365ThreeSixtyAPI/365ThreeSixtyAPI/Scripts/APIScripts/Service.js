app.service("APIService", function ($http) {

    this.createNewAccount = function (newAcc) {
        
       
        return $http(
            {
                method: 'GET',
                url: 'api/createAccount/?' + jQuery.param(newAcc)
            });   

    }

    this.createNewMission = function (newMission) {


        return $http(
            {
                method: 'POST',
                url: 'api/missions',
                data: newMission,
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            });
         

    }
});