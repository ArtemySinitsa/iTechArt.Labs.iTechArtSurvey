const survey = {
    "id": 45,
    "title": "Мой супер опрос",
    "author": "Artemy",
    "questions": [{
        "id": 0,
        "title": "Вопрос с текстовым вариантом ответа",
        "type": "textarea",
        "required": true
    },
    {
        "id": 1,
        "title": "Вопрос с множеством вариантов ответа",
        "type": "checkbox",
        "required": true,
        "options": [
            "Первый вариант",
            "Второй вариант",
            "Третий вариант",
            "Четвертый вариант"
        ]
    },
    {
        "id": 2,
        "title": "Вопрос с выбором одного варианта ответа",
        "type": "radio",
        "required": true,
        "options": [
            "Первый вариант",
            "Второй вариант",
            "Третий вариант",
            "Четвертый вариант"
        ]
    }
        // ,
        // {
        //     "id": 3,
        //     "title": "Вопроc-файл",
        //     "type": "file",
        //     "required": true,
        //     "helpDescription": "Пожалуйста выберите файл..."
        // },
        // {
        //     "id": 4,
        //     "title": "Вопрос-рейтинг",
        //     "type": "rate",
        //     "required": true,
        //     "maxRate": 5
        // },
        // {
        //     "id": 5,
        //     "title": "Вопрос-шкала",
        //     "type": "range",
        //     "minValue": 10,
        //     "maxValue": 250,
        //     "rangeStep": 5
        // }
    ]
};
export default survey;