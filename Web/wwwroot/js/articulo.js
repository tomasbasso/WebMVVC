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
                            'El artículo ha sido eliminado.',
                            'success'
                        )
                    } else {
                        Swal.fire(
                            'Error!',
                            'Hubo un problema al borrar el artículo.',
                            'error'
                        )
                    }
                }
            });
        }
    })
}

function cargarDatatable() {
    if ($.fn.DataTable.isDataTable('#tblArticulos')) {
        $('#tblArticulos').DataTable().destroy();
    }

    dataTable = $("#tblArticulos").DataTable({
        "ajax": {
            "url": "/Admin/Articulo/GetAll",
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data",
            "error": function (xhr, error, thrown) {
                console.error('Error en la llamada AJAX:', error);
                console.error('Detalles:', xhr.responseText);
            }
        },
        "columns": [
            { "data": "idArticulo", "width": "5%" },
            { "data": "nombre", "width": "25%" },
            { "data": "descripcion", "width": "30%" },
            { "data": "categoria.nombre", "width": "15%" }, // Asumiendo que obtienes el nombre de la categoría asociada
            { "data": "fechaCreacion", "width": "10%" },
            {
                "data": "idArticulo",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Admin/Articulo/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick="Delete('/Admin/Articulo/Delete/${data}')" class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-trash-alt"></i> Borrar
                                </a>
                            </div>`;
                },
                "width": "15%"
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
