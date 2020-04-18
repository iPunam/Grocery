function AllowOnlyNumericValue(id,evt) {
    //var specialKeys = new Array();
    //specialKeys.push(8); //BackSpace
    //evt = (evt) ? evt : window.event;
    //var charCode = (evt.which) ? evt.which : evt.keyCode;

    //if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
    //    return false;
    //}
    //return true;
    //var ret = ((charCode >= 48 && charCode <= 57) || specialKeys.indexOf(charCode) != -1);

    //return ret;
    //if (charCode == 8 || charCode == 37) {
    //    return true;
    //}
    //else if (charCode == 46 && $(this).val().indexOf('.') != -1) {
    //    return false;
    //}
    //else if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
    //    return false;
    //}
    //return true;
    var id = document.getElementById(id);
    console.log(id);
    id.addEventListener("input", function (event) {
        AllowOnlyDecimalValue(event);
    });
}

let curValue = '';
function AllowOnlyDecimalValue(event) {
    const valid = /^\d*\.?(?:\d{1,2})?$/;
    //const text = event.target.textContent;
    const text = event.target.value;
    console.log(text);
    if (!valid.test(text)) {
        console.log("1");
        
        event.target.textContent = curValue;
        event.target.blur();
    } else {
        console.log("2");
        curValue = event.target.textContent;
    }
}

var classNames = document.getElementsByClassName('decimalOnly');
for (i = 0; i < classNames.length; i++) {
    //classNames[i].addEventListener("input", function (event) {
    //    AllowOnlyDecimalValue(event);
    //});
    classNames[i].addEventListener("input", AllowOnlyDecimalValue);
}
