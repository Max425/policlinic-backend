import sys
sys.stdout.reconfigure(encoding='utf-8')
import imutils
from imutils.contours import sort_contours
import numpy as np
import pytesseract

pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
import sys
import cv2
import re

import csv
import difflib
import threading
import json
from queue import Queue

rus = ['А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
       'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я']
eng = ['A', 'B', 'V', 'G', 'D', 'E', '2', 'J', 'Z', 'I', 'Q', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'F',
       'H', 'C', '3', '4', 'W', 'X', 'Y', '9', '6', '7', '8']

def change(img):
#     загрузка изображения
    img = cv2.imread(img)
#     изменение размеров
    final_wide = 1400
    r = float(final_wide) / img.shape[1]
    dim = (final_wide, int(img.shape[0] * r))
    img = cv2.resize(img, dim, interpolation = cv2.INTER_AREA)
#     фильтры (оттенки серого, размытие по Гауссу, пороговая обработка)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    blur = cv2.GaussianBlur(gray, (3,3), 0)
    thresh = cv2.threshold(blur, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1]
    kernel = np.ones((7,7), np.uint8)
    kernel = cv2.getStructuringElement(cv2.MORPH_RECT,(3, 3))
    #     морфология изображения (расширение, открытие, закрытие изображения)
    global morph
    morph = cv2.dilate(img, kernel, iterations=9)
    morph = cv2.morphologyEx(thresh, cv2.MORPH_OPEN, kernel)
    morph = cv2.morphologyEx(morph, cv2.MORPH_CLOSE, kernel)
#     поиск контуров (извлечение внешних контуров, получение только 2х основных точек)
    contours = cv2.findContours(morph, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    contours = contours[0] if len(contours) == 2 else contours[1]
    area_thresh = 0
    for c in contours:
        area = cv2.contourArea(c)
        if area > area_thresh:
            area_thresh = area
            big_contour = c
    page = np.zeros_like(img)
#     отрисовка контуров
    cv2.drawContours(page, [big_contour], 0, (255,255,255), -1)
    peri = cv2.arcLength(big_contour, True)
    corners = cv2.approxPolyDP(big_contour, 0.04 * peri, True)
    global polygon
    polygon = img.copy()
    cv2.polylines(polygon, [corners], True, (0,0,255), 3, cv2.LINE_AA)
    yarr = list()
    xarr = list()
    nr = np.empty((0,2), dtype="int32")
    for a in corners:
        for b in a:
            nr = np.vstack([nr, b])
    for i in nr:
        yarr.append(i[0])
        xarr.append(i[1])
    x = min(yarr)
    pX = max(yarr)
    y = min(xarr)
    pY = max(xarr)
    global photo
    photo = img[y:pY, x:pX]
    return photo

def read_ph(photo, imagePathForAns):
    image = photo
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    (H, W) = gray.shape
    rectKernel = cv2.getStructuringElement(cv2.MORPH_RECT, (25, 7))
    sqKernel = cv2.getStructuringElement(cv2.MORPH_RECT, (21, 21))
    gray = cv2.GaussianBlur(gray, (3, 3), 0)
    blackhat = cv2.morphologyEx(gray, cv2.MORPH_BLACKHAT, rectKernel)
    bn = blackhat
    #cv2.imshow('resu', bn)
    #cv2.waitKey(5000)
    config = (" --oem 3 --psm 6 -c tessedit_char_whitelist=0123456789><")
    dataText = pytesseract.image_to_string(image, lang='rus', config=config)
    dataText = dataText.split()
    i = True  # переменная для остановки
    u = 0
    while (i):
        if (len(dataText[u]) == 8):
            i = False
            data_vyd = dataText[u][0:2] + '.' + dataText[u][2:4] + '.' + dataText[u][4:8]
        if (len(dataText[u]) == 2 and len(dataText[u + 1]) == 2 and len(dataText[u + 2]) == 4):
            i = False
            data_vyd = dataText[u] + '.' + dataText[u + 1] + '.' + dataText[u + 2]
        if (len(dataText[u]) == 4 and len(dataText[u + 1]) == 4):
            i = False
            data_vyd = dataText[u][0:2] + '.' + dataText[u][2:4] + '.' + dataText[u+1][0:4]
        u = u + 1
    grad = cv2.Sobel(blackhat, ddepth=cv2.CV_32F, dx=1, dy=0, ksize=-1)
    grad = np.absolute(grad)
    (minVal, maxVal) = (np.min(grad), np.max(grad))
    grad = (grad - minVal) / (maxVal - minVal)
    grad = (grad * 255).astype("uint8")
    grad = cv2.morphologyEx(grad, cv2.MORPH_CLOSE, rectKernel)
    thresh = cv2.threshold(grad, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
    thresh = cv2.morphologyEx(thresh, cv2.MORPH_CLOSE, sqKernel)
    thresh = cv2.erode(thresh, None, iterations=2)
    cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    cnts = imutils.grab_contours(cnts)
    cnts = sort_contours(cnts, method="bottom-to-top")[0]
    mrzBox = None
    for c in cnts:
        (x, y, w, h) = cv2.boundingRect(c)
        percentWidth = w / float(W)
        percentHeight = h / float(H)
        if percentWidth > 0.28 and percentHeight > 0.005:
            mrzBox = (x, y, w, h)
            break
    if mrzBox is None:
        print("[INFO] MRZ could not be found")
        sys.exit(0)
    (x, y, w, h) = mrzBox
    pX = int((x + w) * 0.03)
    pY = int((y + h) * 0.1)
    (x, y) = (x - pX, y - pY)
    (w, h) = (w + (pX * 2), h + (pY * 2))
    global mrz
    picture = bn[y-h//2:y+h//5, x+w//3:x + w]
    config = r'--oem 3 --psm 6 '
    picText = pytesseract.image_to_string(picture, lang='rus', config=config)
    #cv2.imshow('rez', picture)
    #cv2.waitKey(5000)
    res = [x.strip() for x in re.findall(r'[а-яА-ЯёЁ \-]+', picText)]
    e = True  # переменная для остановки
    r = 0
    while (e):
        if res[r].find("ГОР") != -1:
            place = res[r+1]
            e = False
            break
        if res[r].find("Г") != -1:
            place = res[r+1]
            e = False
            break
        if res[r].find("С") != -1:
            place = res[r+1]
            e = False
            break
        if res[r].find("П") != -1:
            place = res[r+1]
            e = False
            break
        r = r + 1
    gender = bn[y-3*h//4:y-h//6, x+w//3:x+w//2]
    #cv2.imshow('res', gender)
    #cv2.waitKey(5000)
    genText = pytesseract.image_to_string(gender, lang='rus', config=config)
    gen = [x.strip() for x in re.findall(r'[а-яА-ЯёЁ \-]+', genText)]
    flag = True  # переменная для остановки
    count = 0
    while (flag):
        if gen[count].find("ЖЕ") != -1:
            gend = "ЖЕН"
            flag = False
            break
        if gen[count].find("МУЖ") != -1:
            gend = "МУЖ"
            flag = False
            break
        count = count + 1
    mrz = bn[y:y + h, x:x + w]
    #cv2.imshow('res', mrz)
    #cv2.waitKey(5000)
    config = (" --oem 3 --psm 6 -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789><")
    #config = r'--oem 3 --psm 6 '
    mrzText = pytesseract.image_to_string(mrz, lang='eng', config=config)
    mrzText = mrzText.replace(" ", "")
    mrzText = mrzText.split()
    if mrzText[0][0:1] != 'P':
        del mrzText[0]
    el1 = mrzText[0]
    el2 = mrzText[1]
    el1 = el1.replace('1', 'I')
    el2 = el2.replace('O', '0')
    el1 = el1[5:]
    el1 = re.split("<<|<|\n", el1)
    el2 = re.split("RUS|<", el2)
    el1 = list(filter(None, el1))
    el1 = list(map(list, el1))
    el1 = el1[0:3]
    el2 = list(filter(None, el2))
    for i in el1:
        for c, j in enumerate(i):
            ind = eng.index(str(j))
            if i[c] == '8':
                i[c] = 'Я'
            if i[c] == '9':
                i[c] = 'Ь'
            i[c] = rus[ind]
    surname = ''.join(el1[0])
    name = ''.join(el1[1])
    otch = ''.join(el1[2])
    seria = el2[0][0:3] + el2[2][0:1]
    nomer = el2[0][3:9]
    data = el2[1][0:6]
    if int(data[0:1]) > 2:
        data = '19' + data
    else:
        data = '20' + data
    data = data[6:8] + '.' + data[4:6] + '.' + data[0:4]
    if (int(data_vyd[6:10]) - int(data[6:10])<14):
        error = "False"
    else:
        error = "True"
    global pasdata
    pasdata = {"LastName": surname, "FirstName": name, "FatherName": otch, "Gender": gend, "City": place, "DateIssue": data_vyd, "BirthDate": data, "PassportSeries": seria, "PassportNumber": nomer, "PhotoBase64": imagePathForAns, "Nationality": "RU"}    
    json_data = json.dumps(pasdata, ensure_ascii=False)
    print(json_data)
    answer = []
    answer.append(surname)
    answer.append(name)
    answer.append(otch)
    return [answer, error]

def result(image):
    try:
        photo = change(image)
        ans = read_ph(photo, image)
        return ans
    except ValueError:
        photo = cv2.imread(image)
        read_ph(photo)
        print(pasdata)

def damerau_levenshtein_distance(word1, word2):
    len1 = len(word1)
    len2 = len(word2)
    matrix = [[0] * (len2 + 1) for _ in range(len1 + 1)]

    for i in range(len1 + 1):
        matrix[i][0] = i

    for j in range(len2 + 1):
        matrix[0][j] = j

    for i in range(1, len1 + 1):
        for j in range(1, len2 + 1):
            cost = 0 if word1[i - 1] == word2[j - 1] else 1
            matrix[i][j] = min(
                matrix[i - 1][j] + 1,  # удаление
                matrix[i][j - 1] + 1,  # вставка
                matrix[i - 1][j - 1] + cost  # замена
            )
            if i > 1 and j > 1 and word1[i - 1] == word2[j - 2] and word1[i - 2] == word2[j - 1]:
                matrix[i][j] = min(
                    matrix[i][j],
                    matrix[i - 2][j - 2] + cost  # транспозиция
                )

    return matrix[len1][len2]

def search(dict, word, atr, result_queue):
    with open(dict, 'r') as file:
        reader = csv.reader(file)
        dictionary = list(reader)

    # Проверяем, есть ли слово в словаре
    found = False
    similar_words = []
    for row in dictionary:
        if word in row[0]:
            found = True
            similar_words.clear()
            break
        elif difflib.SequenceMatcher(None, word, row[0]).ratio() > 0.7:
            similar_words.append(row[0])

    # Выводим результаты
    if found:
        res1 = {"suggestion": word, "distance": 0}
        result_queue.put(res1)
        #print(f'"{atr}" "{word}" есть в словаре')
    else:
        if similar_words:
            spisok = []
            for entry in similar_words:
                distance = damerau_levenshtein_distance(word, entry)
                record = (entry, distance)
                spisok.append(record)
            spisok.sort(key=lambda x: x[1])
            records = []
            for element in spisok[0:15]:
                data_a = {"suggestion": element[0], "distance": element[1]}
                records.append(data_a)
            result_queue.put(records)


        else:
            res2 = {"suggestion": word, "distance": -1}
            result_queue.put(res2)
            # print(f'{atr} "{word}" и похожие на него не найдены в словаре')

def main():
    image_path = sys.argv[1]
    validate = sys.argv[2]
    answ = result(image_path)
    if validate == "True" or validate == "true":
        result_queue1 = Queue()
        result_queue2 = Queue()
        result_queue3 = Queue()

        # Создаем потоки для поиска слова в каждом словаре
        thread1 = threading.Thread(target=search, args=("rus_surnames.csv", answ[0][0], 'surname', result_queue1))
        thread2 = threading.Thread(target=search, args=("rus_names.csv", answ[0][1], 'name', result_queue2))
        thread3 = threading.Thread(target=search, args=("rus_midname.csv", answ[0][2], 'patronym', result_queue3))

        # Запускаем потоки
        thread1.start()
        thread2.start()
        thread3.start()

        # Ожидаем завершения потоков
        thread1.join()
        thread2.join()
        thread3.join()

        result1 = result_queue1.get()
        result2 = result_queue2.get()
        result3 = result_queue3.get()

        merged_data = {"surname": result1, "name": result2, "patronym": result3, "date_matches": answ[1]}
        print(merged_data)

if __name__ == "__main__":
    main()