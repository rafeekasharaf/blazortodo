window.Alert = function(message) {
           alert(message);
};

function deleteConfirmation(title, text, icon) {
    return new Promise(resolve => {
        Swal.fire({
            title,
            text,
            icon,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            buttonsStyling: false,
            customClass:{
                confirmButton: 'btn btn-outline-danger',
                cancelButton: 'btn btn-outline-dark',
            }
          }).then((result) => {
            resolve(result.isConfirmed);            
          });
    });
    
};
