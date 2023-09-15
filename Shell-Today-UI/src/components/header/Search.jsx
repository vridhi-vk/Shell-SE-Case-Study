import React, { useState } from 'react';
import close from '../../images/cancel.png';
import { getDataAPI } from '../../utils/fetchData';
import SearchCard from './SearchCard';

const Search = ({sprite}) => {
    const [search, setSearch] = useState('');
    const [news, setNews] = useState([]);

    const handleSearch = async (e) => {
        e.preventDefault();
        if(!search) 
            return;

        try {

            console.log(search);

            const res = await getDataAPI(`NewsArticle/${search}`);
            console.log(res);
            setNews(res.data.news);
        } catch (err) {
            console.log(err.message)
            err.response.data.msg && setNews({...news});
        }
    };

    const handleClose = () => {
        setSearch('');
        setNews([]);
    };

    return (
        <form className="input-group search__bar" onSubmit={handleSearch}>
            <input
                type="text"
                name="search"
                id="search"
                className="input"
                placeholder="Enter News name here..."
                value={search}
                autoComplete="off"
                onChange={e => setSearch(e.target.value.replace(/ /g, ''))}
            />
            <button className="btn btn--primary">
                {
                    !search && 
                    <>
                        <svg className="icon icon-small">
                            <use href={sprite + "#search"}></use>
                        </svg>
                    </>
                }
            </button>

            <button className="btn btn--primary" onClick={handleClose}>
                {
                    search &&
                    <img className="icon icon-small" src={close} alt="" />
                }
            </button>

            <div className="search">
                {
                    search && news.map(n => (
                        <SearchCard 
                            key={n.articleId}
                            news={n}
                            handleClose={handleClose}
                        />
                    ))
                }
            </div>
        </form>
    )
};

export default Search;