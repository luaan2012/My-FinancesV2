(function ($) {
    'use strict';
    $(function () {
        var todoListItem = $('.todo-list');
        var todoListInput = $('.todo-list-input');
        $('.todo-list-add-btn').on("click", function (event) {
            event.preventDefault();

            var name = $(this).prevAll('.todo-list-input').val();

            if (name) {
                todoListItem.append("<li><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox'/>" + name + "<i class='input-helper'></i></label></div><i class='remove mdi mdi-close-circle-outline'></i></li>");
                todoListInput.val("");

                $.post('/Geral/SaveToDo', { name }, function () {
                })
                    .done(function (result) {
                    })
                    .fail(function (result) {
                        alert(result.message);
                    })
            }
        });

        todoListItem.on('change', '.checkbox', function () {
            var complete = false;

            if ($(this).attr('checked')) {
                $(this).removeAttr('checked');
            } else {
                $(this).attr('checked', 'checked');
            }

            $(this).closest("li").toggleClass('completed');

            if ($('.checkbox').parent().parent().parent().hasClass('completed')) {
                complete = true;
            }

            var id = $(this).parent().parent().parent().attr('data-id');

            $.post('/Geral/CompleteToDo', { id, complete }, function () {
            })
                .done(function (result) {
                })
                .fail(function (result) {
                    alert(result.message);
                })
        });

        todoListItem.on('click', '.remove', function () {
            $(this).parent().remove();
            var id = $(this).parent().attr('data-id');

            $.post('/Geral/RemoveToDo/' + id, { id }, function () {
            })
                .done(function (result) {
                    alert(result.message);
                })
                .fail(function (result) {
                    alert(result.message);
                })
        });

    });
})(jQuery);