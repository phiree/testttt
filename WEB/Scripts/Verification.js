function BtnPay() {
    if ($("[id$='TotalNum']").val() == "") {
        alert("购买数量不能为空");
        return false;
    }
}

function BtnUpdatePrice() {
    if ($("[id$='txtTicketName']").val() == "") {
        alert("门票名称不能为空");
        return false;
    }

    if ($("[id$='txtPrice1']").val() == "") {
        alert("原价不能为空");
        return false;
    }

    if ($("[id$='txtPrice2']").val() == "") {
        alert("预订价不能为空");
        return false;
    }

    if ($("[id$='txtPrice3']").val() == "") {
        alert("优惠价不能为空");
        return false;
    }
}


function BtnUpdateScenicInfo() {
    if ($("[id$='ScenicName']").val() == "") {
        alert("景区名称不能为空");
        return false;
    }

    if ($("[id$='ScenicLevel']").val() == "") {
        alert("景区等级不能为空");
        return false;
    }

    if ($("[id$='Address']").val() == "") {
        alert("景区地址不能为空");
        return false;
    }

    if ($("[id$='hfposition']").val() == "") {
        alert("请在地图上选择景区位置");
        return false;
    }
}