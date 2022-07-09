var i = 0;

function setAttributes(el, attrs) {
    for (var key in attrs) {
        el.setAttribute(key, attrs[key]);
    }
}
function btnthem_click() {
    i++;
    var a = document.getElementById("noidungkhaosat");

    var b = document.createElement("div");
    b.setAttribute("id", "cauhoi" + i);

    var lbl = document.createElement("label");
    lbl.setAttribute("id", "lblcau" + i);
    lbl.innerHTML = "Câu hỏi " + i + ": ";
    b.appendChild(lbl);

    var input = document.createElement("input");
    setAttributes(input, { "type": "text", "id": "txtcauhoi" + i, "name": "txtcauhoi" + i });
    b.appendChild(input);

    var space = document.createTextNode(" ");
    b.appendChild(space);

    var select = document.createElement("select");
    setAttributes(select, { "id": "dangcautraloi" + i, "name": "dangcautraloi" + i, "onchange": "note(value)", "width": "50px" })
    var opt = document.createElement("option");
    opt.setAttribute("value", "");
    opt.innerHTML = "Chọn dạng câu trả lời";
    select.appendChild(opt);
    var opt = document.createElement("option");
    opt.setAttribute("value", "1");
    opt.innerHTML = "Có/Không";
    select.appendChild(opt);
    var opt = document.createElement("option");
    opt.setAttribute("value", "2");
    opt.innerHTML = "Đồng ý/Không đồng ý";
    select.appendChild(opt);
    b.appendChild(select);
    a.appendChild(b);
    var socauhoi = document.getElementById("txtsocauhoi");
    socauhoi.value = i;   
    
}

function note(value) {
    
}

function btnxoa_click() {
    var id = prompt("Bạn muốn xóa câu số mấy?");
    var a = document.getElementById("cauhoi" + id);
    a.remove();
    for (j = Number(id); j < i; j++)
    {
        var ketiep = Number(j) + 1;
        var cauhoi = document.getElementById("cauhoi" + ketiep);
        cauhoi.setAttribute("id", "cauhoi"+ j);
        var label = document.getElementById("lblcau" + ketiep);
        label.setAttribute("id", "lblcau"+ j)
        label.innerHTML = "Câu hỏi " + j + ": ";
        var input = document.getElementById("txtcauhoi" + ketiep);
        input.setAttribute("id", "txtcauhoi" + j);
        var select = document.getElementById("dangcautraloi" + ketiep)
        select.setAttribute("id", "dangcautraloi" + j);
    }
    i = i - 1;
    var socauhoi = document.getElementById("txtsocauhoi");
    socauhoi.value = i;
}
