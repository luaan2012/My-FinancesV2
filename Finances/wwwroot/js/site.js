$('.lembretes, .projetos, .viagens, .dividas').click(function () {
    if ($(this).hasClass('projetos')) {
        $('#modalGeral').css('display', 'block');
        $('#modalGeral').find('.save').addClass('salvarProjeto');
        $('#modalGeral .content').html($('#projetos').html());
        $("#modalGeral .money").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
    } else if ($(this).hasClass('lembretes')) {
        $('#modalGeral').css('display', 'block');
        $('#modalGeral').find('.save').addClass('salvarLembretes');
        $('#modalGeral .content').html($('#lembretes').html())
        $("#modalGeral .money").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
    } else if ($(this).hasClass('dividas')) {
        $('#modalGeral').css('display', 'block');
        $('#modalGeral').find('.save').addClass('salvarDividas');
        $('#modalGeral .content').html($('#dividas').html())
        $("#modalGeral .money").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
    } else if ($(this).hasClass('viagens')) {
        $('#modalGeral').find('.save').addClass('salvarVisitor');
        $('#modalGeral').css('display', 'block');
        $('#modalGeral .content').html($('#viagens').html())
        $("#modalGeral .money").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });
    }
})

function updateGoalProject() {
    $('#modalGoal').css('display', 'block');
}

function updateGoalVisitor() {
    $('#modalVisitor').css('display', 'block');
}

$('.save').click(function (e) {
    e.preventDefault();

    $('#formGeral input').each(function (i, x) {
        var minLenght = $(x).attr("minlength");
        if ($(x).val().length < minLenght && $(x).attr('type') != 'file') {
            $(x).addClass("error");
            $(x).removeClass("right");
        } else {
            $(x).addClass("right");
            $(x).removeClass("error");
        }
    })

    if ($(this).hasClass('salvarProjeto')) {
        AjaxModal(document.getElementById('formGeral'), "/Geral/AddProject", "POST")
    } else if ($(this).hasClass('salvarLembretes')) {
        AjaxModal(document.getElementById('formGeral'), "/Geral/AddRemember", "POST")
    } else if ($(this).hasClass('salvarDividas')) {
        AjaxModal(document.getElementById('formGeral'), "/Geral/AddDebts", "POST")
    } else if ($(this).hasClass('salvarSalario')) {
        AjaxModal(document.getElementById('formGeral'), "/Geral/FirstLogin", "POST")
    } else if ($(this).hasClass('salvarVisitor')) {
        AjaxModal(document.getElementById('formGeral'), "/Geral/SaveVisitor", "POST")
    }

})

function deleteProject(id) {
    $.post('/Geral/RemoveProject', { id })
        .done(function (data) {
            alert(data.message);
        })
        .fail(function (data) {
            alert(data.message);
        })
}

function removeRemember(id) {
    $.post('/Geral/RemoveRemember', { id })
        .done(function (data) {
            alert(data.message);
            window.location.reload
        })
        .fail(function (data) {
            alert(data.message);
        })
}

function removeDebts(id) {
    $.post('/Geral/RemoveDebts', { id })
        .done(function (data) {
            alert(data.message);
            window.location.reload
        })
        .fail(function (data) {
            alert(data.message);
        })
}

function AjaxModal(elemento, url, metodo) {
    var money = $('.money').val();
    if (money) {
        $('.money').val(money.replace('R$',''))
    }
    var formData = new FormData(elemento);

    $.ajax({
        url: url,
        type: metodo,
        data: formData,
        success: function (data) {
            console.log(data)
            if (data) {
                alert(data.message)
                window.location.reload();
            }
        },
        error: function (data) {
            if (data) {
                alert(data.message)
                window.location.reload();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

function changePay(id, pay) {
    $.post('/Geral/ChangePay', { id, pay })
        .done(function (data) {
            alert(data.message);
            window.location.reload
        })
        .fail(function (data) {
            alert(data.message);
        })
}


//var modal = document.getElementById("modalGeral")

//var span = document.getElementsByClassName("close")[0];

//var cancel = document.getElementsByClassName("modal-cancel")[0];


//$(window).click(function (event) {
//    if (event.target == modal)
//        modal.style.display = "none";
//})

$(".modal-cancel").click(function () {
    $(".modal").css("display", "none")
})

$(".close").click(function () {
    $(".modal").css("display", "none")
})


