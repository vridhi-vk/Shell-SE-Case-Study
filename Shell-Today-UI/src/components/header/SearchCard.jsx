import React from 'react';
import { Link } from 'react-router-dom';

const SearchCard = ({news, handleClose}) => {
    let title = news.title.slice(0, 20);
    if(title.length > 19)
        title += '...';
    return (
        <Link to={`/news/${news.articleId}`} className="search__card" onClick={handleClose}>
            <img src={news.thumbnail} className="search__img" alt="news"/>
            <h2 className="search__title">{title}</h2>
        </Link>
    )
};

export default SearchCard;