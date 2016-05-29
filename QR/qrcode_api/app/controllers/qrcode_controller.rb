require 'zxing/decodable'

class QrcodeController < ActionController::Base
  # Prevent CSRF attacks by raising an exception.
  # For APIs, you may want to use :null_session instead.
  
  def show
  	render text: "Show"
  end

  def decode
 
	decodedString = ZXing.decode params[:url]
 	#decodedString = ZXing.decode 'Google Drive/testing QR/Screenshot 20116-05-28 21.10.37.png'
  	#file = File.open(params[:filedata].original_filename)
#  	ZXing.decode params[:filedata]
  	#render text: params[:filedata].original_filename
  	result = {'decodedString' => decodedString}
  	render json: result
#  	render json: result.to_json
  end
end
