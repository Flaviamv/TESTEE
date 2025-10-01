class SwalUtils {
    static success = (message, reload = false) =>
        Swal.fire({
            title: 'Sucesso',
            text: message,
            icon: 'success',
            confirmButtonText: 'Ok',
        }).then(() => {
            if (reload) {
                location.reload();
            }
        });

    static warn = (message) =>
        Swal.fire({
            title: 'Atenção',
            text: message,
            icon: 'warning',
            confirmButtonText: 'Ok',
        });

    static error = (message) =>
        Swal.fire({
            title: 'Erro',
            text: message,
            icon: 'error',
            confirmButtonText: 'Ok',
        });

    static confirm = (message) => {
        return Swal.fire({
            title: 'Atenção',
            text: message,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim',
            cancelButtonText: 'Não'
        }).then((result) => {
            return result.isConfirmed;
        });
    }
}