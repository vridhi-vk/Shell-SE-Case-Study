import React from 'react';
import { useState, useEffect } from 'react';
import { getDataAPI } from './../utils/fetchData';
import HomeCard from './HomeCard';
import registerImage from '../images/register.jpg';

const Home = () => {
    const [news, setNews] = useState([]);
    
    useEffect(() => {
        async function fetchData() {
            const res = await getDataAPI('NewsArticle');
            // const res = {
            //     'data': {
            //         'news': [
            //             {'images': [registerImage],'title': "what a news", 'des': " THIS is descript"}, 
            //             {'images': [registerImage],'title': "this is news", 'des': "this is descpritpon"},
            //             {'images': [registerImage],'title': "this is news", 'des': "this is descpritpon"},
            //             {'images': [registerImage],'title': "this is news", 'des': "this is descpritpon"}
            //         ]
            //     }
            // }
            // console.log(data)
            setNews(res.data);
            console.log(res.data);
        };
        fetchData();
    }, []);

    return (
        <div className="main">
            {
                news.map(n => (
                    <HomeCard n={n}/>
                ))
            }
        </div>
    )
};

export default Home;