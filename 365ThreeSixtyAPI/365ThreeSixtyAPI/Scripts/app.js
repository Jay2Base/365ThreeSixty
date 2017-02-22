var ViewModel = function () {
    var self = this;
    self.employees = ko.observableArray();
    self.error = ko.observable();

    var booksUri = '/api/employee/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        
        var userId = { userAccountId: 1 };
        
        var j = jQuery.param(userId);
        
        ajaxHelper(booksUri + '?' + j,'GET').done(function (data) {
            self.employees(data);
        });
    }

    // Fetch the initial data.
    getAllBooks();
};

ko.applyBindings(new ViewModel());
