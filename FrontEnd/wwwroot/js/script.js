var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.5.1.min.js';
document.getElementsByTagName('head')[0].appendChild(script);  

let turn = true;
let gameState;
let i = 0;
let pending = false;
async function buttonAction(button) {
    let data = await fetch('http://localhost:3681/api/map/', {
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(button)
    })
    i++;
    console.log(i);
    console.log("before await");
    var gameState = await data.json();
    console.log(gameState);
    await checkGame(gameState);
    console.log("after check");

    $(function () {
        $.getScript("http://localhost:3681/api/turns/");
    });
}

function change(button) {
    if (pending) {
        return;
    }
    var btn = document.getElementById(button.id);
    btn.value = turn ? "X" : "O";
    turn = !turn;
    btn.disabled = true;
    let buttonInfo = {
        id: button.id,
        value: button.value
    }
    pending = true;
    buttonAction(buttonInfo);
}

async function checkGame(game) {
    if (game.endGame.showEndGameMessage == true) {
        alert("Player " + game.endGame.currentWinner + " win!")
        let elements = document.querySelectorAll("input[type=button]");
        for (var i = 0, len = elements.length; i < len; i++) {
            elements[i].disabled = false;
            elements[i].value = "";
        }
    }
    $.ajax({
        url: "http://localhost:3681/api/map",
        method: "PATCH"
    })
    pending = false;
}
