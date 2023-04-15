// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function FillUsers(lstBranchCtrl, lstUserId) {

    var lstUsers = $("#" + lstUserId);
    lstUsers.empty();



    var selectedBranch = lstBranchCtrl.options[lstBranchCtrl.selectedIndex].value;

    if (selectedBranch != null && selectedBranch != '') {
        $.getJSON("/Projects/GetUsersByBranch", { BranchId: selectedBranch }, function (users) {
            if (users != null && !jQuery.isEmptyObject(users)) {
                $.each(users, function (index, user) {
                    lstUsers.append($('<option/>',
                        {
                            value: user.value,
                            text: user.text
                        }));
                });
            };
        });
    }

    return;
}