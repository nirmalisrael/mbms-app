function Confirm() {
    var confirm_value = document.createElement('INPUT');
    confirm_value.type = 'hidden';
    confirm_value.name = 'confirm_value';
    if (confirm("Are you sure you want to delete this User?")) {
        confirm_value.value = 'Yes';
    }
    else {
        confirm_value.value = 'No';
    }
    document.forms[0].appendChild(confirm_value);
}

function confirmDelete() {
    var confirmValue = confirm("Are you sure you want to delete this User?");
    document.getElementById("confirm_value").value = confirmValue ? "Yes" : "No";

}
function confirmDelete() {
    var confirmValue = confirm("Are you sure you want to delete this User?");
    document.getElementById('<%= confirm_value.ClientID %>').value = confirmValue ? "Yes" : "No";
    return confirmValue;
}