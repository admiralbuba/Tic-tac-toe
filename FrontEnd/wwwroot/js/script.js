var script = document.createElement('script');
script.src = '//code.jquery.com/jquery-3.5.1.min.js';
document.getElementsByTagName('head')[0].appendChild(script);  

async function buttonAction(button) {
    let data = await fetch('http://localhost:3681/api/map/', {
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(button)
    }).then(
        function (response) {
            response.json().then(function (data) {
                console.log(data);
            });}
    )

    $(function () {
        $.getScript("http://localhost:3681/api/turns/");
    });
}
function change(button) {
    var btn = document.getElementById(button.id);
    btn.value = btn.value == "X" ? "O" : "X";
    let buttonInfo = {
        id: button.id,
        value: button.value
    }
    buttonAction(buttonInfo);
}

