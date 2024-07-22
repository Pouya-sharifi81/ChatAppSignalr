function receive(text) {
    console.log(text);
}

//invole = فراخوانی کردن
function sendMessage(event) {
    event.preventDefault();
    var text = $("#messageText").val();
    connection.invoke("SendMessage", text);
}

function appendGroup(groupName, token, imageName) {
    if (groupName === "Error") {
        alert("ERROR");
    } else {
        $(".rooms #user_groups ul").append(`
                                             <li onclick="joinInGroup('${token}')">
                                            ${groupName}
                                            <img src="/image/groups/${imageName}" />
                                            <span></span>
                                        </li>
                                            `);
        $("#exampleModal").modal({ show: false });
    }
}

function insertGroup(event) {
    event.preventDefault();
    var groupName = event.target[0].value;
    var imageFile = event.target[1].files[0];
    var formData = new FormData();
    formData.append("GroupName", groupName);
    formData.append("ImageFile", imageFile);
    $.ajax({
        url: "/home/CreateGroup",
        type: "post",
        data: formData,
        encytype: "multipart/form-data",
        processData: false,
        contentType: false
    });
}

function search() {
    var text = $("#search_input").val();
    if (text) {
        $("#search_result").show();
        $("#user_groups").hide();
        $.ajax({
            url: "/home/search?title=" + text,
            type: "get"
        }).done(function (data) {
            $("#search_result ul").html("");
            for (var i in data) {
                if (data[i].isUser) {
                    $("#search_result ul").append(`
                                 <li data-user-id='${data[i].token}'>
                                            ${data[i].title}
                                            <img src="/img/${data[i].imageName}" />
                                            <span></span>
                                        </li>
                        `);
                } else {
                    $("#search_result ul").append(`
                                 <li onclick="joinInGroup('${data[i].token}')">
                                            ${data[i].title}
                                            <img src="/image/groups/${data[i].imageName}" />
                                            <span></span>
                                        </li>

                        `);
                }
            }

        });
    } else {
        $("#search_result").hide();
        $("#user_groups").show();
    }
}