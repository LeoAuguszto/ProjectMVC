
function openModal(id, name) {
    var modal = new bootstrap.Modal(document.getElementById('deleteModal-' + id));
    var modalBody = document.getElementById('modalBody-' + id);

    if (modalBody) {
        modalBody.innerHTML = `Tem certeza que deseja apagar o contato: <span style="font-weight: bold; color: red;">${name}</span>?`;
        modal.show();
    } else {
        alert(`Elemento(s) não encontrado(s) no DOM.`);
        console.error("Elemento(s) não encontrado(s) no DOM.");
    }
}
