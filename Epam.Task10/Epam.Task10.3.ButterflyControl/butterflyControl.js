var { all2Selected, availableField, selectedField, all2Available, toSelected, toAvailable } = newFunction();

all2Selected.onclick = function () {
    all2SelectOrAvailable(availableField, selectedField);
}

all2Available.addEventListener('click', function () {
    all2SelectOrAvailable(selectedField, availableField);
});

toSelected.addEventListener('click', function () {
    toSelectOrAvailable(availableField, selectedField);
});

toAvailable.addEventListener('click', function () {
    toSelectOrAvailable(selectedField, availableField);
});

function newFunction() {
    var availableField = document.getElementById('available');
    var selectedField = document.getElementById('selected');
    var all2Selected = document.getElementById('all2Selected');
    var all2Available = document.getElementById('all2Available');
    var toSelected = document.getElementById('toSelected');
    var toAvailable = document.getElementById('toAvailable');
    
    return { all2Selected, availableField, selectedField, all2Available, toSelected, toAvailable };
}

function displayErrorMessage() {
    if (availableField.selectedIndex == -1 &&
        selectedField.selectedIndex == -1) {
            alert('Choose an option from the list.');
        }
}

function all2SelectOrAvailable(field1, field2) {
    while (field1.options.length > 0) {
        field2.appendChild(field1.options[0]);
    }
}

function toSelectOrAvailable(field1, field2) {
    displayErrorMessage();
    if (field1.options.length > 0) {
        field2.appendChild(field1.options[field1.selectedIndex]);
    }

    field2.selectedIndex = -1;
}