$(document).ready(function () {
    var progressstatus = 40
    $('.StepNext').click(function () {
        if (progressstatus == 80) {
            progressstatus += 20;
        } if (progressstatus == 40) {
            progressstatus += 40;
        }
        $('#Progressbar').css('width', '' + progressstatus + '%');
        switch (progressstatus) {
            case 80:
                $('#JobPosting-tab').addClass('active');
                $('#pills-Company').removeClass('active');
                $('#pills-Company').removeClass('show');
                $('#pills-JobPosting').addClass('active');
                $('#pills-JobPosting').addClass('show');
                break;
            case 100:
                $('#Recruit-tab').addClass('active');
                $('#pills-JobPosting').removeClass('active');
                $('#pills-JobPosting').removeClass('show');
                $('#pills-Recruit').addClass('active');
                $('#pills-Recruit').addClass('show');
                break;
        }
    });
    $('.StepBack').click(function () {
        if (progressstatus == 80) {
            progressstatus -= 40;
        } if (progressstatus == 100) {
            progressstatus -= 20;
        }
        $('#Progressbar').css('width', '' + progressstatus + '%');
        switch (progressstatus) {
            case 40:
                $('#JobPosting-tab').removeClass('active');
                $('#Company-tab').addClass('active');
                $('#pills-Company').addClass('active');
                $('#pills-Company').addClass('show');
                $('#pills-JobPosting').removeClass('active');
                $('#pills-JobPosting').removeClass('show');
                break;
            case 80:
                $('#Recruit-tab').removeClass('active');
                $('#JobPosting-tab').addClass('active');
                $('#pills-JobPosting').addClass('active');
                $('#pills-JobPosting').addClass('show');
                $('#pills-Recruit').removeClass('active');
                $('#pills-Recruit').removeClass('show');
                break;
        }
    });
    $('#Company-tab').click(function () {
        progressstatus = 40
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Company-tab').addClass('active');
        $('#JobPosting-tab').removeClass('active');
        $('#Recruit-tab').removeClass('active');

        $('#pills-Company').addClass('active');
        $('#pills-Company').addClass('show');
        $('#pills-JobPosting').removeClass('active');
        $('#pills-JobPosting').removeClass('show');
        $('#pills-Recruit').removeClass('active');
        $('#pills-Recruit').removeClass('show');

    });
    $('#JobPosting-tab').click(function () {
        progressstatus = 80
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Company-tab').addClass('active');
        $('#JobPosting-tab').addClass('active');
        $('#Recruit-tab').removeClass('active');

        $('#pills-Company').removeClass('active');
        $('#pills-Company').removeClass('show');
        $('#pills-JobPosting').addClass('active');
        $('#pills-JobPosting').addClass('show');
        $('#pills-Recruit').removeClass('active');
        $('#pills-Recruit').removeClass('show');
    });
    $('#Recruit-tab').click(function () {
        progressstatus = 100
        $('#Progressbar').css('width', '' + progressstatus + '%');
        $('#Company-tab').addClass('active');
        $('#JobPosting-tab').addClass('active');
        $('#Recruit-tab').addClass('active');

        $('#pills-Company').removeClass('active');
        $('#pills-Company').removeClass('show');
        $('#pills-JobPosting').removeClass('active');
        $('#pills-JobPosting').removeClass('show');
        $('#pills-Recruit').addClass('active');
        $('#pills-Recruit').addClass('show');
    });
});