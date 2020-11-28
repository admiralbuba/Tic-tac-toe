const buttonAction = async (button) => {
    const response = await fetch('http://localhost:3681/api/map/', {
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(button)
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