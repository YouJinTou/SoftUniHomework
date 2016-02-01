var tableData = {
    data: [
        {
            'name': 'Gary Finch',
            'jobtitle': 'Front End Technical Lead',
            'website': 'http://website.com'
        },
        {
            'name': 'Bob McFray',
            'jobtitle': 'Photographer',
            'website': 'http://goo.gle'
        },
        {
            'name': "Jenny O'Sullivan",
            'jobtitle': 'LEGO Geek',
            'website': 'http://stackoverflow.com'
        }]
}

var app = app || {};

app.table = (function () {
    function Table(selector, data) {
		this.selector = selector;
		this.data = data;
	}
		
		Table.prototype.buildTable = function () {
			var tableRow;
			
			$.get('templates/tableDataTemplate.html', function (template) {
            tableData.data.forEach(function (obj) {
                tableRow = Mustache.render(template, obj);
                $(this.selector).append(tableRow);
            })
        })
		}    

    return {
        load: function (selector, data) {
            return new Table(selector, data);
        }
    }
})();

var table = app.table.load('tbody', tableData);

table.buildTable();

