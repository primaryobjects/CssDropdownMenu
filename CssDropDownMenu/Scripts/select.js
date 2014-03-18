var cssMenuManager = {
    initialize: function () {
        // Click on dropdown text.
        $(".dropdown-selection").click(function () {
            var dropdown = $(this).closest('.dropdown');

            if (cssMenuManager.isActive(dropdown)) {
                // Hide menu.
                dropdown.find(".dropdown-menu").hide();
                $(this).removeClass('active');
            }
            else {
                // Show menu.
                dropdown.find(".dropdown-menu").show();
                $(this).addClass('active');
            }
        });

        // Click on menu.
        $(".dropdown-menu").mouseup(function () {
            var dropdown = $(this).closest('.dropdown');

            if (cssMenuManager.isActive(dropdown)) {
                // Hide menu.
                $(this).hide();
                dropdown.find('.dropdown-selection').removeClass('active');
            }

            return false;
        });

        // Click on dropdown option.
        $('.dropdown-menu .dropdown-options li > a').click(function () {
            var dropdown = $(this).closest('.dropdown');
            var select = dropdown.find('select');

            // Hide menu.
            dropdown.find('.dropdown-menu').hide();
            dropdown.find('.dropdown-selection').removeClass('active');

            // Remove active option.
            dropdown.find('li').removeClass('active');

            // Set active option.
            var activeOption = $(this).closest('li');
            activeOption.addClass('active');

            // Update text.
            dropdown.find('.dropdown-selection .text').text(activeOption.text());

            // Update underlying select option.
            select.val(activeOption.data('value'));

            // Trigger change event.
            select.change();

        });

        // Change event on underlying select option.
        $('.dropdown').find('select').change(function () {
            var dropdown = $(this).closest('.dropdown');

            // Remove active option.
            dropdown.find('li').removeClass('active');

            // Set active option.
            var activeOption = dropdown.find('[data-value=' + $(this).val() + ']');
            activeOption.addClass('active');

            // Update text.
            dropdown.find('.dropdown-selection .text').text(activeOption.text());
        });

        // Click on document, close all dropdown menus.
        $(document).mouseup(function () {
            // Hide menu.
            $(".dropdown-menu").hide();
            $('.dropdown-selection').removeClass('active');
        });

        // Initialilze active option to the value selected in the underlying dropdown.
        $('.dropdown').each(function () {
            var dropdown = $(this);
            var select = dropdown.find('select');

            // Remove active option.
            dropdown.find('li').removeClass('active');

            // Set active option.
            var activeOption = dropdown.find('[data-value=' + select.val() + ']');
            activeOption.addClass('active');

            // Update text.
            dropdown.find('.dropdown-selection .text').text(activeOption.text());
        });
    },

    isActive: function (dropdown) {
        return dropdown.find('.dropdown-selection').hasClass('active');
    }
};

$(document).ready(function () {
    cssMenuManager.initialize();
});