var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function Delete(url) {
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, bórralo!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        Swal.fire(
                            'Borrado!',
                            'La categoría ha sido eliminada.',
                            'success'
                        )
                    } else {
                        Swal.fire(
                            'Error!',
                            'Hubo un problema al borrar la categoría.',
                            'error'
                        )
                    }
                }
            });
        }
    })
}
function cargarDatatable() {
    if ($.fn.DataTable.isDataTable('#tblCategorias')) {
        $('#tblCategorias').DataTable().destroy();
    }

    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/Admin/Categoria/GetAll",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data",
            "error": function (xhr, error, thrown) {
                console.error('Error en la llamada AJAX:', error);
                console.error('Detalles:', xhr.responseText);
            }
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "40%" },
            {
                "data": "habilitada",
                "width": "10%",
                "render": function (data) {
                    return data ? "Sí" : "No";
                }
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admin/Categoria/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick="Delete('/Admin/Categoria/Delete/${data}')" class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-trash-alt"></i> Borrar
                                </a>
                            </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}