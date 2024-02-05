function showCustomerEditModal(customerData) {

    document.getElementById('editCustomerId').value = customerData.CustomerId;
    document.getElementById('editName').value = customerData.Name;
    document.getElementById('editEmail').value = customerData.Email;
    document.getElementById('editPhone').value = customerData.PhoneNumber;

    $('#editCustomerModal').modal('show');
}
