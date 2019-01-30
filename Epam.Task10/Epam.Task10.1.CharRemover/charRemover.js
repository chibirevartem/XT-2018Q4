
var ignore = ["?", "!", ":", ";", ",", ".", " ", "\t", "\r"];
var letters = {}, result;
var str,words;

document.getElementById('submitButton').onclick = function () {
    str = document.getElementById('input').value;
    words = str.split(' ');
    words.forEach(function (word) {
        word.split('').forEach(function (letter, i) {
            if (!letters[letter] && ignore.indexOf(letter) == -1 && -1 != word.indexOf(letter, i + 1))
            {
                letters[letter] = 1;
            }
        });
    });
    result = str.split('').filter(function (v) {
        return !letters[v];
    }).join('');
    document.getElementById('output').value = result;

}



 
