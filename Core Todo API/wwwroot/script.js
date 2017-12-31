function addNewTodo(data) {
    var todo = "<li class='todo' id='" + data.id +
        "' completed='" + data.completed + "'>" + data.title + " <i class='fa fa-times' aria-hidden='true'></i><i class='fa fa-check' aria-hidden='true'></i></li>";

    $("#todos").prepend(todo);
    markCompletedItems();
}

function markCompletedItems() {
    $(".todo[completed='true']").each(function (i, obj) {
        $(obj).css("opacity", ".3");
        $(obj).appendTo(".todo-list");
    });

    $(".todo[completed='false']").each(function (i, obj) {
        $(obj).css("opacity", "1");
    });
}

$(document).ready(function () {
    $.get("/api/values", function (data) {
        for (i = 0; i < data.length; i++) {
            addNewTodo(data[i]);
        }
    });

    $("body").on("click", ".fa-times", function () {
        var todoRemoveButton = $(this);
        $.ajax({
            url: '/api/values/' + $(this).parent().attr("id"),
            type: 'DELETE',
            success: function () {
                $(todoRemoveButton).parent().remove();
            }
        });
    });

    $("body").on("click", ".fa-check", function () {
        var todoCheckButton = $(this);
        var newState = true;
        if ($(todoCheckButton).parent().attr("completed") == "true") {
            newState = false;
        }

        $.ajax({
            url: '/api/values/' + $(this).parent().attr("id") + "?completed=" + newState,
            type: 'PUT',
            success: function () {
                $(todoCheckButton).parent().attr("completed", newState);
                markCompletedItems();
            }
        });
    });

    $("#new-todo").keypress(function (e) {
        if (e.which == 13) {
            var todo = { "title": $(this).val() };
            $.ajax({
                url: "/api/values",
                type: "POST",
                data: JSON.stringify(todo),
                contentType: "application/json",
                success: function (data) {
                    addNewTodo(data);
                    $("#new-todo").val("");
                }
            });
        }
    });
});