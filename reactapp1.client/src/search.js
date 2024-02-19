// eslint-disable-next-line no-unused-vars
import React, { useState } from 'react';
import axios from 'axios';

const Search = () => {
    const [query, setQuery] = useState('');
    const [results, setResults] = useState([]);

    const handleChange = (event) => {
        setQuery(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.get(`https://api.bing.microsoft.com/v7.0/search?q=${query}`, {
                headers: {
                    // eslint-disable-next-line no-undef
                    'Ocp-Apim-Subscription-Key': process.env.REACT_APP_BING_API_KEY,
                },
            });
            setResults(response.data.webPages.value);
        } catch (error) {
            console.error('Error fetching search results:', error);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="text" value={query} onChange={handleChange} />
                <button type="submit">Search</button>
            </form>
            <ul>
                {results.map((result) => (
                    <li key={result.id}>
                        <a href={result.url}>{result.name}</a>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Search;