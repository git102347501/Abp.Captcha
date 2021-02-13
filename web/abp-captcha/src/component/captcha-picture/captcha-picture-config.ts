/**
 * 获取验证图片信息
 */
export class CaptchaPictureConfig {
    index: string;
    content: string;

    /**
     * 构造函数
     */
    constructor (index: string,content: string) {
        this.index = index;
        this.content = content;
    }
}   
