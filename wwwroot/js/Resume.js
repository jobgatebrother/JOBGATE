$(document).ready(function () {
    var progressstatus = 20
    $('.StepNext').click(function () {
        progressstatus += 20
        $('#Progressbar').css('width', '' + progressstatus + '%');
        switch (progressstatus) {
            case 40:
                $('#Education-tab').addClass('active');
                $('#pills-Personel').removeClass('active');
                $('#pills-Personel').removeClass('show');
                $('#pills-Education').addClass('active');
                $('#pills-Education').addClass('show');
                break;
            case 60:
                $('#Experience-tab').addClass('active');
                $('#pills-Education').removeClass('active');
                $('#pills-Education').removeClass('show');
                $('#pills-Experience').addClass('active');
                $('#pills-Experience').addClass('show');
                break;
            case 80:
                $('#Skill-tab').addClass('active');
                $('#pills-Experience').removeClass('active');
                $('#pills-Experience').removeClass('show');
                $('#pills-Skill').addClass('active');
                $('#pills-Skill').addClass('show');
                break;
            case 100:
                $('#Job-tab').addClass('active');
                $('#pills-Skill').removeClass('active');
                $('#pills-Skill').removeClass('show');
                $('#pills-Job').addClass('active');
                $('#pills-Job').addClass('show');
                break;
        }
    });
    $('.StepBack').click(function () {
        progressstatus -= 20
        $('#Progressbar').css('width', '' + progressstatus + '%');
        switch (progressstatus) {
            case 20:
                $('#Education-tab').removeClass('active');
                $('#Personel-tab').addClass('active');
                $('#pills-Personel').addClass('active');
                $('#pills-Personel').addClass('show');
                $('#pills-Education').removeClass('active');
                $('#pills-Education').removeClass('show');
                break;
            case 40:
                $('#Experience-tab').removeClass('active');
                $('#pills-Education').addClass('active');
                $('#pills-Education').addClass('show');
                $('#pills-Experience').removeClass('active');
                $('#pills-Experience').removeClass('show');
                break;
            case 60:
                $('#Skill-tab').removeClass('active');
                $('#pills-Experience').addClass('active');
                $('#pills-Experience').addClass('show');
                $('#pills-Skill').removeClass('active');
                $('#pills-Skill').removeClass('show');
                break;
            case 80:
                $('#Job-tab').removeClass('active');
                $('#pills-Skill').addClass('active');
                $('#pills-Skill').addClass('show');
                $('#pills-Job').removeClass('active');
                $('#pills-Job').removeClass('show');
                break;
        }
    });
    $('#Personel-tab').click(function () {
        progressstatus = 20
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Personel-tab').addClass('active');
        $('#Education-tab').removeClass('active');
        $('#Experience-tab').removeClass('active');
        $('#Skill-tab').removeClass('active');
        $('#Job-tab').removeClass('active');

        $('#pills-Personel').addClass('active');
        $('#pills-Personel').addClass('show');
        $('#pills-Education').removeClass('active');
        $('#pills-Education').removeClass('show');
        $('#pills-Experience').removeClass('active');
        $('#pills-Experience').removeClass('show');
        $('#pills-Skill').removeClass('active');
        $('#pills-Skill').removeClass('show');
        $('#pills-Job').removeClass('active');
        $('#pills-Job').removeClass('show');

    });
    $('#Education-tab').click(function () {
        progressstatus = 40
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Personel-tab').addClass('active');
        $('#Education-tab').addClass('active');
        $('#Experience-tab').removeClass('active');
        $('#Skill-tab').removeClass('active');
        $('#Job-tab').removeClass('active');

        $('#pills-Personel').removeClass('active');
        $('#pills-Personel').removeClass('show');
        $('#pills-Education').addClass('active');
        $('#pills-Education').addClass('show');
        $('#pills-Experience').removeClass('active');
        $('#pills-Experience').removeClass('show');
        $('#pills-Skill').removeClass('active');
        $('#pills-Skill').removeClass('show');
        $('#pills-Job').removeClass('active');
        $('#pills-Job').removeClass('show');
    });
    $('#Experience-tab').click(function () {
        progressstatus = 60
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Personel-tab').addClass('active');
        $('#Education-tab').addClass('active');
        $('#Experience-tab').addClass('active');
        $('#Skill-tab').removeClass('active');
        $('#Job-tab').removeClass('active');

        $('#pills-Personel').removeClass('active');
        $('#pills-Personel').removeClass('show');
        $('#pills-Education').removeClass('active');
        $('#pills-Education').removeClass('show');
        $('#pills-Experience').addClass('active');
        $('#pills-Experience').addClass('show');
        $('#pills-Skill').removeClass('active');
        $('#pills-Skill').removeClass('show');
        $('#pills-Job').removeClass('active');
        $('#pills-Job').removeClass('show');
    });
    $('#Skill-tab').click(function () {
        progressstatus = 80
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Personel-tab').addClass('active');
        $('#Education-tab').addClass('active');
        $('#Experience-tab').addClass('active');
        $('#Skill-tab').addClass('active');
        $('#Job-tab').removeClass('active');

        $('#pills-Personel').removeClass('active');
        $('#pills-Personel').removeClass('show');
        $('#pills-Education').removeClass('active');
        $('#pills-Education').removeClass('show');
        $('#pills-Experience').removeClass('active');
        $('#pills-Experience').removeClass('show');
        $('#pills-Skill').addClass('active');
        $('#pills-Skill').addClass('show');
        $('#pills-Job').removeClass('active');
        $('#pills-Job').removeClass('show');
    });
    $('#Job-tab').click(function () {
        progressstatus = 100
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Personel-tab').addClass('active');
        $('#Education-tab').addClass('active');
        $('#Experience-tab').addClass('active');
        $('#Skill-tab').addClass('active');
        $('#Job-tab').addClass('active');

        $('#pills-Personel').removeClass('active');
        $('#pills-Personel').removeClass('show');
        $('#pills-Education').removeClass('active');
        $('#pills-Education').removeClass('show');
        $('#pills-Experience').removeClass('active');
        $('#pills-Experience').removeClass('show');
        $('#pills-Skill').removeClass('active');
        $('#pills-Skill').removeClass('show');
        $('#pills-Job').addClass('active');
        $('#pills-Job').addClass('show');
    });
});
