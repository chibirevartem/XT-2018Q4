var arithmeticsRegex = /\s*(\d+\.?\d*)\s*/;
var str;
var result = 0.0;
var expressions;

function getSign(arr) {
    if (arr[0] === '-') {
        result = -arr[1];
    }
    else if (arr[0] === '+' || arr[0] === '') {
        result = +arr[1];
    }
    else {
        result = 'Input Error';
    }
}

function IsValidate(arr) {
    if (arr[arr.length - 1] !== '=') {
        return false;
    }

    if (typeof(+arr[arr.length - 2]) !== 'number') {
        return false;
    }

    return true;
}

function calculate(arr) {
    for (var i = 2; i < arr.length - 2; i = i+2) {
        switch (arr[i]) {
            case '+':
            result += +arr[i + 1];
            break;

            case '-':
            result -= +arr[i + 1];
            break;

            case '*':
            result *= +arr[i + 1];
            break;

            case '/':
            result /= +arr[i + 1];
            break;

            case '=':
            break;

            default:
            result = 'Input Error';
            return;
        }
    }
}

document.getElementById('submitButton').onclick = function () {
    str = document.getElementById('input').value;
    expressions = str.split(arithmeticsRegex);

    if (!IsValidate(expressions)) {
        result = 'Input Error';
    }
    else {
        getSign(expressions);
        calculate(expressions);
        if (result != 'Input Error') {
            result = result.toFixed(2);
        }
    }
    document.getElementById('output').value = result;
    event.preventDefault();
}