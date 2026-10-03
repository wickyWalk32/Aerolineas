
// JS directo (problemas con el renderizado / carga de la página)

/*window.focusElementById = function (id) {
    const element = document.getElementById(id);
    if (element) {
        element.focus();
    }
};*/


// JS Interop con el enfoque moderno de Blazor: espera a que la página cargue y llama el código JS cuando se lo pide en "Login.razor.cs".

// Implementar función que pone el foco en el input de email usando un módulo ES6 de JS.

export function ponerFoco(idElemento) {
    const elemento = document.getElementById(idElemento);
    if (elemento) {
        elemento.focus();
    }
}