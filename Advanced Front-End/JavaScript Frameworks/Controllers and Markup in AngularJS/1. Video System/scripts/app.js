var app = angular.module('videoCatalogue', []);

app.value('videoCatalogue', [{
    title: 'Course introduction',
    pictureUrl: 'https://www.openfest.org/2015/wp-content/uploads/sites/18/2014/10/softuni.jpg',
    length: '3:32',
    category: 'IT',
    subscribers: 3,
    date: new Date(2014, 12, 15),
    haveSubtitles: false,
    comments: [
		{
		    username: 'Pesho Peshev',
		    content: 'Congratulations Nakov',
		    date: new Date(2014, 12, 15, 12, 30, 0),
		    likes: 3,
		    websiteUrl: 'http://pesho.com/'
		}
    ]
},
{
    title: 'Course Advanced',
    pictureUrl: 'http://www.advancedcomputersoftware.com/images/logos/adv-head-logo.png',
    length: '4:12',
    category: 'IT',
    subscribers: 10,
    date: new Date(2015, 6, 11),
    haveSubtitles: true,
    comments: [
		{
		    username: 'Pesho Peshev',
		    content: 'Top notch stuff!',
		    date: new Date(2014, 12, 15, 12, 30, 0),
		    likes: 12,
		    websiteUrl: 'http://pesho.com/'
		},
        {
            username: 'Asen Asenov',
            content: 'LOLLMFAO!',
            date: new Date(2014, 12, 21, 12, 30, 0),
            likes: 2,
            websiteUrl: 'http://asen.com'
        }
    ]
},
{
    title: 'Course Proficient',
    pictureUrl: 'http://www.corporatefacilitysupply.com/wp-content/uploads/2012/03/word-from-the-expert.jpg',
    length: '12:41',
    category: 'Ninja',
    subscribers: 120,
    date: new Date(2016, 02, 28),
    haveSubtitles: true,
    comments: [
		{
		    username: 'Pesho Peshev',
		    content: 'This is getting difficult...',
		    date: new Date(2016, 9, 1, 12, 30, 0),
		    likes: 5,
		    websiteUrl: 'http://pesho.com/'
		},
        {
            username: 'Asen Asenov',
            content: 'Have to agree with you',
            date: new Date(2016, 12, 21, 12, 30, 0),
            likes: 2,
            websiteUrl: 'http://asen.com'
        },
        {
            username: 'Gosho Ivanov',
            content: 'Are you kidding me, guys? That is easy!',
            date: new Date(2016, 12, 21, 12, 32, 0),
            likes: 0,
            websiteUrl: 'http://gosho.com'
        }
    ]
}])