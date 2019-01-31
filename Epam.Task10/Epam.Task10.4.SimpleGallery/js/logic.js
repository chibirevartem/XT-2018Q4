var seconds = 5,
    playFlag = false,
    startBtn = document.getElementById('start'),
    stopBtn = document.getElementById('stop'),
    playBtn = document.getElementById('play'),
    prevBtn = document.getElementById('prev'),
    nextBtn = document.getElementById('next'),
    startAgainBtn = document.getElementById('startAgain'),
    closeBtn = document.getElementById('close'),
    counter = document.getElementById('counter'),
    urls = ['1.html', '2.html', '3.html'];

function play(url) {
    go = true;
    timer(url);
}

function stop() {
    go = false;
}

function timer(url) {
    if (!go) {
        return;
    }

    counter.innerText = seconds;
    seconds--;
    if (seconds < 0) {
        redirect(url);
    }

    setTimeout(timer, 1000, url);
}

function redirect(url) {
    location = url;
}