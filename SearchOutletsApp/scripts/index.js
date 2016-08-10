var baseUrl = 'http://localhost:55804'; // default to relative path
var API_URL = baseUrl + '/api/Users';


$(function() {
    GenerateIndexPage();
});

function GenerateIndexPage() {
    GenerateUserTemplate();
    LoadTable();
}
function GenerateUserTemplate() {
    var userTemplate = '<div class="table-content"><a href="/" class="nav-link"><h3 class="page-header">User Dashboard</h3></a>\r\n    <table id="table" data-pagination="true" data-show-refresh="true" data-sort-name="FirstName" data-sort-order="asc" data-search="true" data-toolbar=".toolbar">\r\n        <thead>\r\n            <tr id="header">\r\n                <th data-field="Name" data-width="11%" data-sortable="true">Name <i class="fa fa-level-down" aria-hidden="true"></i></i>\r\n                </th>\r\n                <th data-field="OutletName" data-align="center" data-width="16%" data-sortable="true" class="jira-key-style">Outlet Name <i class="fa fa-level-down" aria-hidden="true"></i></i>\r\n                </th>\r\n                <th data-field="Title" data-align="center" data-width="14%" data-sortable="true" class="jira-key-style">Title <i class="fa fa-level-down" aria-hidden="true"></i></i>\r\n                </th>\r\n                <th data-field="Profile" data-align="center" data-width="14%" data-sortable="true" class="latest-email-style">Profile <i class="fa fa-level-down" aria-hidden="true"></i></i>\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n    </table>\r\n</div>';
    Mustache.parse(userTemplate);   // optional, speeds up future uses
    var rendered = Mustache.render(userTemplate);
    $('#content').html(rendered);
    $('body').css('background-color', '#fff');
}

function LoadTable() {
    GetData(API_URL).done(function (data) {
        var $table = $('#table').bootstrapTable({
            url: API_URL,
        });
        if (!$('.pull-right.search .fa-search').length) {
            $('.pull-right.search').prepend('<i class="fa fa-search" aria-hidden="true"></i>');
        }
    }).fail(function (data) {
        NotifyErrorAndThrow('Failed to get the user data!');
    });
}

function GetData(apiUrl) {
    return $.ajax({
        url: apiUrl,
        type: "GET",
        crossDomain: true,
        contentType: "application/json"
    });
}

