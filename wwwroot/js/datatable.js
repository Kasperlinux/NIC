$(document).ready(function () {
    $('#dataTableData').DataTable({
        dom: 'Bfrtip', // Show buttons (B) - Buttons for exporting, filtering (f), and table info (r), and pagination (t), and input (i)
        buttons: [
            'copyHtml5', // Copy to clipboard
            'excelHtml5', // Export to Excel
            'csvHtml5',   // Export to CSV
            'pdfHtml5',   // Export to PDF
            'print'       // Print button
        ]
    });
})